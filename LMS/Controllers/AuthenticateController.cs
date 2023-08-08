using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.MODELS.ViewModel.Auth;
using AutoMapper;
using LMS.DATA.Model;
using LMS.MODELS.Response.CompanyResponse;
using LMS.SERVICES.Intefaces;
using LMS.API.Reponses;
using Microsoft.AspNetCore.Identity;
using LMS.MODELS.Constants;
using LMS.SERVICES.Services;
using System.Text;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public AuthenticateController(IMapper mapper, ICompanyService companyService, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserService userService, IEmailService emailService )
        {
            _mapper = mapper;
            _companyService = companyService;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("signup-admin")]
        public async Task<IActionResult> SignUpAdmin([FromBody] SignUpVm model)
        {
            if (ModelState.IsValid)
            {
                var compModel = _mapper.Map<Company>(model.CompanyVM);

                var companyReponse = new CreateCompanyReponse();
                try
                {
                    // Create company
                    compModel.EnteredBy = model.Username;
                    compModel.DateEntered = DateTime.Now;
                    compModel.Status = model.Status; //"Registered";
                    compModel.IsDeleted = false;

                    companyReponse = await _companyService.CreateCompanyAsync(compModel);
                    if (companyReponse != null && !companyReponse.Success)
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Status = "Error", Message = "Shelter creation failed! Please check shelter details and try again." });


                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Status = "Error", Message = "Oops! Something wrong for shelter entry!", Message2 = "Error occurred at Shelter entry: " + ex.Message });
                }
                int companyId = companyReponse != null && companyReponse.Data != null && companyReponse.Success ? companyReponse.Data.Id : 0;
                ApplicationUser user = new ApplicationUser()
                {
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AlternateEmailAddress = model.AlternateEmailAddress,
                    Notes = model.Notes,
                    CompanyId = companyId,
                    DateEntered = DateTime.Now,
                    EnteredBy = model.Username,
                    Status = "active"  // The status to be stored is either ‘Trialer’ or ‘Active’ based on the button that was clicked to get to this screen.
                };
                try
                {

                    // Create User associated with company
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        await _companyService.DeleteAsync(companyId);
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Status = "Error", Message = "User creation failed! Please check user details and try again." });
                    }
                    await _userManager.AddToRoleAsync(user, UserRoles.Administrator);

                }
                catch (Exception ex)
                {
                    // Delete company entry
                    await _companyService.DeleteAsync(companyId);
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Status = "Error", Message = "Oops! Something wrong for user entry.", Message2 = "Error occurred at User entry: " + ex.Message });
                }
                try
                {
                    string strToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(strToken));
                    //Add Email Exipration for token 
                    await _userService.AddTokenExpiration(user, EmailTokenType.SignUpToken);
                    await _emailService.EmailVerification(user.FirstName + " " + user.LastName, user.Email, token);
                }
                catch (Exception ex)
                {
                    // Delete tenant and users from both tables
                    await _userManager.DeleteAsync(user);
                    await _companyService.DeleteAsync(companyId);
                    // Sending real message for error while sending email in Message 2 for reference where it is failing
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Status = "Error", Message = "Oops! Something wrong for sending verification email. Please try again.", Message2 = "Error occurred at sending verification email: " + ex.Message });
                }
                return Ok(new Response { Success = true, Status = "Success", Message = "User created successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Status = "Error", Message = "Invalid signup payload!" });
            }
        }
     }
}
