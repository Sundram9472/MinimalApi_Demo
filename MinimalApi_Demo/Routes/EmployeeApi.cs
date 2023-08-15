using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MinimalApi_Demo.AppDbContext;
using MinimalApi_Demo.Entities;

namespace MinimalApi_Demo.Routes
{
    public static class EmployeeApi
    {
      public  static void MapEmployeeApiRoutes(this IEndpointRouteBuilder app) {



            //get the list of EmployeeAttendanceSheet
            app.MapGet("/GetAllEmployee",[Authorize] async (EmployeeDbContext db) =>
             await db.EmployeeAttendanc.ToListAsync());

            //get EmployeeAttendanceSheet details
            app.MapPut("/GetEmployee/{id}", [Authorize] async (int EmployeeId, EmployeeDbContext db) =>
            {
               var emp  = await db.EmployeeAttendanc.FindAsync(EmployeeId);
                return Results.Ok(emp);
            });

            //create a new EmployeeAttendanceSheet
            app.MapPost("/SaveEmployee", [Authorize] async (EmployeeAttendancSheet Emp, EmployeeDbContext db) =>
            {
                db.EmployeeAttendanc.Add(Emp);
                await db.SaveChangesAsync();

                return Results.Created($"/save/{Emp.EmployeeId}", Emp);
            });

            //edit a EmployeeAttendanceSheet
            app.MapPut("/UpdateEmployee/{id}", [Authorize] async (int id, EmployeeAttendancSheet empinput, EmployeeDbContext db) =>
            {
                var Emp = await db.EmployeeAttendanc.FindAsync(id);

                if (Emp is null) return Results.NotFound();

                Emp.EmployeeName = empinput.EmployeeName;
                Emp.EmployeeEmailId = empinput.EmployeeEmailId;
                Emp.EmployeeTeam = empinput.EmployeeTeam;
                Emp.EmployeePresent = empinput.EmployeePresent;
                Emp.EmployeeAbsent = empinput.EmployeeAbsent;
                Emp.EmployeeTakeLeave = empinput.EmployeeTakeLeave;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            //delete a EmployeeAttendanceSheet
            app.MapDelete("/DeleteEmployee/{id}", [Authorize] async (int id, EmployeeDbContext db) =>
            {
                if (await db.EmployeeAttendanc.FindAsync(id) is EmployeeAttendancSheet emp)
                {
                    db.EmployeeAttendanc.Remove(emp);
                    await db.SaveChangesAsync();
                    return Results.Ok(emp);
                }

                return Results.NotFound();
            });

        }
    }
}
