// using Application.Features.Products.Commands.Create;
// using Application.Features.Products.Commands.Delete;
// using Application.Features.Products.Commands.Update;
// using Application.Features.Products.Queries.GetAll;
// using Application.Features.Products.Queries.GetById;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Server.Controllers;
//
// [Authorize]
// [ApiController]
// [Route(template: "[controller]")]
// [Produces(contentType: "application/json")]
// public class ProductsController(IMediator mediator) : ControllerBase
// {
//
//     /// <summary>
//     /// Crea un nuevo producto.
//     /// </summary>
//     /// <param name="command">El comando que contiene los datos del producto a crear.</param>
//     /// <returns>Un resultado que indica el estado de la creación del producto.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /Products
//     ///     {
//     ///        "categoryId": "XXXX-XXXX-XXXX-XXXX",
//     ///        "name": "Cafetera eléctrica",
//     ///        "description": "Una cafetera eléctrica moderna.",
//     ///        "image": "http://example.com/image.jpg",
//     ///        "sellPrice": 49.99,
//     ///        "purchasePrice": 30.00,
//     ///        "stock": 100
//     ///     }
//     ///
//     /// </remarks>
//     /// <response code="201">Devuelve el producto recién creado.</response>
//     /// <response code="400">Si hay errores en la creación del producto.</response>
//     [HttpPost]
//     [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
//     [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
//     public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
//     {
//         var result = await mediator.Send(command);
//         if (result.Succeeded)
//         {
//             return CreatedAtAction(nameof(GetById), routeValues: new { id = result.Value }, value: result);
//         }
//         return BadRequest(result.Errors);
//     }
//     
//     /// <summary>
//     /// Obtiene todos los productos.
//     /// </summary>
//     /// <returns>Una lista de todos los productos disponibles.</returns>
//     /// <response code="200">Devuelve una lista de productos.</response>
//     [HttpGet]
//     [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetAll(int pageSize, int pageNumber)
//     {
//         var result = await mediator.Send(request: new GetAllProductsQuery(pageSize, pageNumber));
//         return Ok(result);
//     }
//     
//     /// <summary>
//     /// Obtiene un producto específico por su identificador único.
//     /// </summary>
//     /// <param name="id">El identificador único del producto.</param>
//     /// <returns>El producto correspondiente al ID proporcionado.</returns>
//     /// <response code="200">Devuelve el producto encontrado.</response>
//     /// <response code="404">Si no se encuentra el producto con el ID especificado.</response>
//     [HttpGet(template: "{id:guid}")]
//     [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
//     [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
//     public async Task<IActionResult> GetById(Guid id)
//     {
//         var result = await mediator.Send(request: new GetProductByIdQuery(id));
//         return Ok(result);
//     }
//     
//     /// <summary>
//     /// Actualiza un producto existente.
//     /// </summary>
//     /// <param name="id">El identificador único del producto a actualizar.</param>
//     /// <param name="command">El comando que contiene los datos actualizados del producto.</param>
//     /// <returns>Un resultado que indica el estado de la actualización del producto.</returns>
//     /// <response code="204">Si la actualización fue exitosa.</response>
//     /// <response code="400">Si el ID no coincide o hay errores en la actualización.</response>
//     [HttpPut(template: "{id:guid}")]
//     [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
//     [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
//     public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest(error: "El ID del producto no coincide.");
//         }
//
//         var result = await mediator.Send(command);
//         if (result.Succeeded)
//         {
//             return NoContent();
//         }
//         return BadRequest(result.Errors);
//     }
//     
//     /// <summary>
//     /// Elimina lógicamente un producto especificando su identificador único.
//     /// </summary>
//     /// <param name="id">El identificador único del producto a eliminar.</param>
//     /// <returns>Un resultado que indica si la eliminación fue exitosa o no.</returns>
//     /// <response code="204">Si la eliminación fue exitosa.</response>
//     /// <response code="404">Si no se encuentra el producto con el ID especificado.</response>
//     [HttpDelete(template: "{id:guid}")]
//     [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
//     [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
//     public async Task<IActionResult> Delete(Guid id)
//     {
//         var result = await mediator.Send(request: new DeleteProductCommand(id));
//         if (result.Succeeded)
//         {
//             return NoContent();
//         }
//         return NotFound();
//     }
// }