using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.Repository
{
    public class LogChanges<T> where T : class
    {

        private T beforeChage;
        private T afterChange;
        private T deleted;
        private T inserted;
        private List<T> groupInserted;

        public string TableName { get; set; } = typeof(T).Name;
        public string ActionName { get; set; }

        public T BeforeChage
        {
            get { return beforeChage; }
            set
            {
                beforeChage = value.Clone();
            }
        }
        public T AfterChange
        {
            get { return afterChange; }
            set
            {
                afterChange = value.Clone();
            }
        }

        public T Detelted
        {
            get { return deleted; }
            set
            {
                deleted = value.Clone();
            }
        }
        public T Inserted
        {
            get { return inserted; }
            set
            {
                inserted = value.Clone();
            }
        }

        public List<T> GroupInserted
        {
            get { return groupInserted; }
            set
            {
                groupInserted = value.Clone();
            }
        }
    }
}
