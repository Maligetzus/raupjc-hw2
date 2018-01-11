using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class TodoItem
    {

        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted
        {
            get { return DateCompleted.HasValue; }
        }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            // Generates new unique identifier
            Id = Guid.NewGuid();
            // DateTime .Now returns local time , it wont always be what you expect
            // (depending where the server is).
            // We want to use universal (UTC ) time which we can easily convert to
            // local when needed.
            // ( usually done in browser on the client side )
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override bool Equals(Object item)
        {
            if (item is TodoItem)
            {
                TodoItem pom = (TodoItem) item;
                if (pom.Id == this.Id) return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()*12 + Text.GetHashCode()*24 + IsCompleted.GetHashCode()*36 + DateCompleted.GetHashCode()*48 + DateCreated.GetHashCode()*60;
        }


    }
}