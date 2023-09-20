using EasyBank.Models;

namespace EasyBank.Services
{
    public class ActionLogger
    {
        private readonly DataContext _db;
        public ActionLogger(DataContext db)
        {
            _db = db;
        }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Id { get; set; }
        public async Task LogAsync(string status)
        {
            if (int.TryParse(Id, out int id))
            {
                if (_db.EmployeeActions != null)
                {
                    await _db.EmployeeActions.AddAsync(new EmployeeAction(Controller, Action, status, id));
                    await _db.SaveChangesAsync();
                }
            }
        }
    }
}
