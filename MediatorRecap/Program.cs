using System;
using System.Collections.Generic;

namespace MediatorRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            var teamLead = new TeamLead(mediator);
            var furkan = new Member(mediator);
            teamLead.Name = "Ahmet";
            furkan.Name = "Furkan";
            var mehmet = new Member(mediator);
            mehmet.Name = "Mehmet";
            mediator.TeamLead = teamLead;
            mediator.Members.Add(furkan);
            mediator.Members.Add(mehmet);
            teamLead.AddAnoounce("Merhaba");
        }
    }
    public abstract class Engineer
    {
        protected Mediator Mediator;
        public Engineer(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    public class TeamLead:Engineer
    {
        public TeamLead(Mediator mediator):base(mediator)
        {

        }
        public void AddAnoounce(string text)
        {
            Console.WriteLine($"Added Announce {text}");
            Mediator.Announce();
        }
        public string Name { get; set; }
    }
    public class Member:Engineer
    {
        public Member(Mediator mediator):base(mediator)
        {

        }
        public void ReceiveAnnouncement()
        {
            Console.WriteLine($"{Name} received message");
        }
        public string Name { get; set; }
    }
    public class Mediator
    {
        public TeamLead TeamLead { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();

        public void Announce()
        {
            foreach (var member in Members)
            {
                member.ReceiveAnnouncement();
            }
        }
    }
}
