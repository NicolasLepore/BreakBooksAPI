using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.SupplierDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BooksContext _context;

        public SupplierController(IMapper mapper, BooksContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] CreateSupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadSupplierById), new { id = supplier.Id }, supplier);
        }

        [HttpGet]
        public IActionResult ReadSuppliers([FromQuery] int skip = 0, [FromQuery] int take = 30)
        {
            var suppliers = _context.Suppliers.Skip(skip).Take(take).ToList();
            var suppliersDto = _mapper.Map<List<ReadSupplierDto>>(suppliers);
            return Ok(suppliersDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadSupplierById(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if(supplier == null) return NotFound();
            var supplierDto = _mapper.Map<ReadSupplierDto>(supplier);
            return Ok(supplierDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] UpdateSupplierDto supplierDto)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null) return NotFound();

            _mapper.Map(supplierDto, supplier);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateSupplier(int id, 
            [FromBody]JsonPatchDocument<UpdateSupplierDto> patch)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null) return NotFound();
            var mappedSupplier = _mapper.Map<UpdateSupplierDto>(supplier);

            patch.ApplyTo(mappedSupplier, ModelState);
            if(!TryValidateModel(mappedSupplier)) return ValidationProblem(ModelState);

            _mapper.Map(mappedSupplier, supplier);
            _context.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if(supplier == null) return NotFound();
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return NoContent();
        }
    }
}