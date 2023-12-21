using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Data;
using WebApplication1.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace WebApplication1.Pages
{
    public class debuggerTestingRightModel : PageModel
    {

        public List<SelectListItem> StatesList { get; set; }
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Code for data is from the following repository which does the work with services, while no services used here
        /// as that is not what this is about along with zero client side validation.
        /// https://github.com/karenpayneoregon/dropdowns-razor-pages/tree/master/InjectIntoViewApplication
        /// </summary>
        public debuggerTestingRightModel(IConfiguration configuration)
        {
            Configuration = configuration;

            using var context = new Context(Configuration.GetConnectionString("ReferencesConnection"));
            List<StateLookup> states = context.StateLookup.AsNoTracking().ToList();
            states.Insert(0, new StateLookup() { Id = -1, StateAbbrev = "XX", StateName = "" });

            StatesList = states.Select(sl =>
                new SelectListItem
                {
                    Value = sl.Id.ToString(),
                    Text = sl.StateName
                }).ToList();

            Person = new Person();

        }

        public void OnGet()
        {

        }

        [BindProperty]
        public int StateIdentifier { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnPost()
        {
            if (StateIdentifier == -1)
            {
                return Page();
            }
            
            using var context = new Context(Configuration.GetConnectionString("ReferencesConnection"));
            var state = context.StateLookup.FirstOrDefault(x => x.Id == StateIdentifier);
            Person.State = state!.Id;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Log.Information("Business name {P1}", Person.BusinessName);
                Log.Information("Account number {P1}", Person.AccountNumber);
                Log.Information("Contact {P1}", Person.ContactPerson);
                Log.Information("Address {P1}", Person.Address);
                Log.Information("City {P1}", Person.City);
                Log.Information("Zip {P1}", Person.ZipCode);
                Log.Information("State name {P1} state id {P2}", state.StateName, Person.State);

                return RedirectToPage("Index");
            }
        }
    }
}
