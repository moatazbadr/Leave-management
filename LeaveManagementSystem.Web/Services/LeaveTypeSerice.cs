using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypeService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<List<LeaveTypesReadOnly>> GetAllLeaveTypesAsync()
        {
            var data = await _context.leaveTypes.ToListAsync();
            return _mapper.Map<List<LeaveTypesReadOnly>>(data);
        }

        public async Task<T?> GetleaveTypeAsync<T>(int id) where T : class
        {
            if (id < 0)
            {
                return null;
            }
            var leaveType = await _context.leaveTypes.FirstOrDefaultAsync(l => l.Id == id);
            if (leaveType == null)
            {
                return null;
            }
            return _mapper.Map<T>(leaveType);

        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                return;
            }
            var leaveType = await _context.leaveTypes.FirstOrDefaultAsync(l => l.Id == id);
            if (leaveType == null)
            {
                return;
            }
            _context.leaveTypes.Remove(leaveType);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(LeaveTypesCreateVM leaveTypesCreate)
        {
            if (leaveTypesCreate == null)
            {

                return;
            }
            var leaveType = _mapper.Map<LeaveType>(leaveTypesCreate);
            await _context.leaveTypes.AddAsync(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(LeaveTypeEditVM leaveTypeEdit)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
            _context.leaveTypes.Update(leaveType);
            await _context.SaveChangesAsync();

        }

        public bool LeaveTypeExists(int id)
        {
            return _context.leaveTypes.Any(e => e.Id == id);
        }


        public async Task<bool> CheckLeaveType(string name)
        {
            name = name.ToLower().Trim();
            return await _context.leaveTypes.AnyAsync(l => l.Name.ToLower().Trim() == name);
        }

        
    } 
}
    
