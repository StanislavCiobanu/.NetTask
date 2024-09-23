using System;
using System.Text.RegularExpressions;
using Tasks23_26;
using Tasks23_26.Task26;


//ExecuteTask21();
//ExecuteTask23();
//ExecuteTask24();
ExecuteTask25();
//ExecuteTask26();


void ExecuteTask21()
{
    Task21 task = new Task21();
    task.Execute();
}

void ExecuteTask23()
{
    Task23 task = new Task23();
    task.Execute();
}

void ExecuteTask24()
{
    Task24 task = new Task24();
    task.Execute();
}

void ExecuteTask25()
{
    Task25 task = new Task25();
    task.Execute();
}

void ExecuteTask26()
{
    User user1 = new User("Ciobanu Stanislav", "StanislavCiobanu@endava.com");
    User user2 = new User("Test user", "@@@@TestUser@endava.com");

    EmailService service = EmailService.Instance;

    service.SendEmail(user1.CreateEmail("Hey body! How are you doing?"), user2);

    try
    {
        service.ServiceUnavialableThrow();
    }
    catch
    {
        service.SendEmail(user1.CreateEmail("Something was wrong with the server, but now everything is ok"), user2);
    }

}