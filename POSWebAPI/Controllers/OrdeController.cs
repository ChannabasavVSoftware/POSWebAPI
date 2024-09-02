//using Microsoft.AspNetCore.Mvc;


//namespace RestaurantManagementSystem.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdeController : ControllerBase
//    {
//        private static List<Order> _Orders = new List<Order>
//        {
//            new Order { CustomerId = 1,OrderDate =new System.DateTime(),CustomerName="Santhosh",TotalAmount=23090,  },
//            new Order { CustomerId = 2,OrderDate =new System.DateTime(),CustomerName="Shubam",TotalAmount=23091, },         //OrderItems=new List<OrderItem> {new OrderItem { Id = 3 }, } },
//            new Order { CustomerId = 3,OrderDate =new System.DateTime(),CustomerName="Santh",TotalAmount=23092, },
//            new Order { CustomerId = 4,OrderDate =new System.DateTime(),CustomerName="Basava",TotalAmount=23093,  },
//            new Order { CustomerId = 5,OrderDate =new System.DateTime(),CustomerName="Shammi",TotalAmount=23094,  },
//            new Order { CustomerId = 6,OrderDate =new System.DateTime(),CustomerName="Virat",TotalAmount=23095, },
//            new Order { CustomerId = 7,OrderDate =new System.DateTime(),CustomerName="Ganguly",TotalAmount=23096, },
//            new Order { CustomerId = 8,OrderDate =new System.DateTime(),CustomerName="Chetri",TotalAmount=23097,  }

//        };
//        [HttpGet]
//        public ActionResult<IEnumerable<Order>> GetProducts()
//        {
//            return _Orders;
//        }

//        //Get  through id 

//        [HttpGet("{id}")]
//        public ActionResult<Order> GetProduct(int id)
//        {
//            var ProductId = _Orders.FirstOrDefault(p => p.CustomerId == id);
//            if (ProductId == null)
//            {
//                return NotFound();
//            }
//            return Ok(ProductId);
//        }
//        //create new record through id
//        [HttpPost]
//        public ActionResult PostProduct(Order product)
//        {
//            _Orders.Add(product);
//            return CreatedAtAction(nameof(PostProduct), new { id = product.CustomerId }, product);
//        }

//        //Update existing record through id 
//        [HttpPut("{CustomerId}")]
//        public IActionResult PutProduct(int id, Order product)
//        {
//            if (id != product.CustomerId)
//            {
//                return BadRequest();
//            }
//            var existingProduct = _Orders.FirstOrDefault(p => p.CustomerId == id);
//            if (existingProduct == null)
//            {
//                return NotFound();
//            }
//            existingProduct.CustomerName = product.CustomerName;
//            existingProduct.TotalAmount = product.TotalAmount;
//            existingProduct.OrderDate = product.OrderDate;
//            existingProduct.OrderItems = product.OrderItems;
//            return NoContent();
//        }

//        //Delete record through id
//        [HttpDelete("{id}")]
//        public IActionResult DeleteProduct(int customerid)
//        {
//            var productid = _Orders.FirstOrDefault(p => p.CustomerId == customerid);
//            if (productid == null)
//            {

//                return NotFound();
//            }
//            _Orders.Remove(productid);

//            return Ok();


//        }
//    }
//}