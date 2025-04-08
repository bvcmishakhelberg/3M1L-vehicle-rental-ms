//using _3M1L_vehicle_rental_ms.Models;
//using _3M1L_vehicle_rental_ms.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace _3M1L_vehicle_rental_ms.Controllers
//{
//    public class CustomerController : Controller
//    {
//        private readonly RentalDbContext RentalDbContext;


//        public CustomerController(RentalDbContext RentalDbContext)
//        {
//            this.RentalDbContext = RentalDbContext;
//        }

//        // Get all jokes
//        [HttpGet]
//        [Route("Joke")]
//        public async Task<IActionResult> Index()
//        {
//            var jokes = await RentalDbContext.Jokes.ToListAsync();
//            return View(jokes);
//        }

//        // Get one joke
//        [HttpGet]
//        [Route("Joke/Details/{id}")]
//        public async Task<IActionResult> Details(int id)
//        {
//            var joke = await RentalDbContext.Jokes.FirstOrDefaultAsync(a => a.Id == id);
//            return View(joke);
//        }

//        // Get the Add.cshtml page
//        [HttpGet]
//        [Route("Joke/Add")]
//        public IActionResult Add()
//        {
//            return View();
//        }

//        // Create a new joke
//        [HttpPost]
//        [Route("Joke/Add")]
//        public async Task<IActionResult> Add(Vehicle joke)
//        {
//            if (ModelState.IsValid)
//            {
//                var newjoke = new Vehicle()
//                {
//                    JokeQuestion = joke.JokeQuestion,
//                    JokeAnswer = joke.JokeAnswer,
//                };
//                await RentalDbContext.Jokes.AddAsync(newjoke);
//                await RentalDbContext.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(joke);
//        }

//        // Get Edit.cshtml page
//        [HttpGet]
//        [Route("Joke/Edit/{id}")]
//        public async Task<IActionResult> Edit(int id)
//        {
//            var joke = await RentalDbContext.Jokes.FirstOrDefaultAsync(a => a.Id == id);
//            return View(joke);
//        }
        
//        // Edit one joke
//        [HttpPost]
//        [Route("Joke/Edit/{id}")]
//        public async Task<IActionResult> Edit(Vehicle NewJoke)
//        {
//            if (ModelState.IsValid)
//            {
//                var joke = await RentalDbContext.Jokes.FindAsync(NewJoke.Id);
//                if (joke != null)
//                {
//                    joke.JokeQuestion = NewJoke.JokeQuestion;
//                    joke.JokeAnswer = NewJoke.JokeAnswer;
//                    await RentalDbContext.SaveChangesAsync();
//                    return RedirectToAction("Index");
//                }
                
//            }
//            return View(NewJoke);
//        }

//        // Delete
//        [HttpGet]
//        [Route("Joke/Delete/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var joke = await RentalDbContext.Jokes.FindAsync(id);
//            if (joke != null)
//            {
//                RentalDbContext.Jokes.Remove(joke);
//                await RentalDbContext.SaveChangesAsync();
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}
