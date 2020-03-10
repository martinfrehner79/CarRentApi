using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Interfaces;


namespace CarRentApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentApiBaseController<TEntity, TEntityDto, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TEntityDto : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
       

        public CarRentApiBaseController(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<TEntity> entityList = await _repository.GetAllAsync().ConfigureAwait(false);
                var entityDto = entityList.Select(x => _mapper.Map<TEntity, TEntityDto>(x)).ToList();
                return Ok(entityDto);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            try
            {
                var entity = await _repository.GetAsync(guid).ConfigureAwait(false);
                if (entity == null)
                {
                    return NotFound();
                }
                var entityDto = _mapper.Map<TEntityDto>(entity);
                return Ok(entityDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Put(Guid guid, TEntity entity)
        {
            try
            {
                if (guid != entity.Guid)
                {
                    return BadRequest();
                }
                await _repository.UpdateAsync(entity).ConfigureAwait(false);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TEntity entityDto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(entityDto);
                await _repository.AddAsync(entity).ConfigureAwait(false);
                return Ok(entityDto);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(Guid guid)
        {
            try
            {
                await _repository.DeleteAsync(guid).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

   