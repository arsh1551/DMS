using CoreEntites.Helper;
using CoreEntities.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{
    public class UnityOfWork : IDisposable
    {
        private DbContext _context;
        public Dictionary<Type, object> Repositories { get; private set; }
        public UnityOfWork(DbContext context)
        {
            
            Repositories = new Dictionary<Type, object>();
            _context = context;
        }


        private Dictionary<Type, List<LogProperty>> AuditInfo { get; set; }

        /// <summary>
        /// List of types that will be logged by the application
        /// </summary>
        private List<LogType> TypesToLog { get; set; }
      

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();



        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            //TypesToLog = this.Repository<LogType>().GetAll().ToList();
            ////get a list of the changes that the user made
            //var logs = new List<Log>();
            //var properties = new List<LogPropertyChange>();
            //int? userId = null;
            //DateTime now = DateTime.Now;
            //foreach (var entry in _context.ChangeTracker.Entries<object>())
            //{
            //    var entryType = entry.Entity.GetType();
            //    var typeInfo = (from i in TypesToLog
            //                    where i.Key == entryType.Name || entryType.Name.StartsWith(i.Key + "_")
            //                    select i).FirstOrDefault();
            //    if (typeInfo != null)
            //    {
            //        int objectId = 0;
            //        string clientId = "";
            //        int? parentId = null;
            //        Guid logId = Guid.NewGuid();
            //        var message = "";
            //        switch (entry.State)
            //        {
            //            case EntityState.Added:
            //                objectId = (int)entry.CurrentValues[typeInfo.IdName];
            //                if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
            //                    //Value that identifies the object for the user (Name, number, etc)
            //                    clientId = (entry.CurrentValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
            //                message = string.Format("A new {0} was created ({1})", typeInfo.Name, clientId);
            //                if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
            //                    //Id of the parent (to be logged in children objects)
            //                    parentId = (int)entry.CurrentValues[typeInfo.ParentIdName];
            //                break;
            //            case EntityState.Deleted:
            //                objectId = (int)entry.OriginalValues[typeInfo.IdName];
            //                if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
            //                    //Value that identifies the object for the user (Name, number, etc)
            //                    clientId = (entry.OriginalValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
            //                message = string.Format("The {0} {1} was deleted.", typeInfo.Name, clientId);
            //                if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
            //                    //Id of the parent (to be logged in children objects)
            //                    parentId = (int)entry.OriginalValues[typeInfo.ParentIdName];
            //                break;
            //            case EntityState.Detached:
            //                break;
            //            case EntityState.Modified:
            //                objectId = (int)entry.CurrentValues[typeInfo.IdName];

            //                if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
            //                    //Id of the parent (to be logged in children objects)
            //                    parentId = (int)entry.CurrentValues[typeInfo.ParentIdName];
            //                if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
            //                    //Value that identifies the object for the user (Name, number, etc)
            //                    clientId = (entry.OriginalValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
            //                var sb = new StringBuilder();
            //                sb.AppendLine(string.Format("The {0} {1} was updated.", typeInfo.Name, clientId));
            //                //Go through each of the properties that will be logged
            //                foreach (var property in FieldsToLog(entryType))
            //                {
            //                    string originalValue = entry.OriginalValues[property.Key] == null ? "" : entry.OriginalValues[property.Key].ToString();
            //                    string currentValue = entry.CurrentValues[property.Key] == null ? "" : entry.CurrentValues[property.Key].ToString();

            //                    if (originalValue != currentValue)
            //                    {
            //                        if (property.LogValues)
            //                        {
            //                            sb.AppendLine(string.Format("-The value of {0} changed from {1} to {2}.", property.Name, originalValue, currentValue));
            //                            //Log the changes to each property
            //                            Guid LogPropertyChangeId = Guid.NewGuid();
            //                            properties.Add(new LogPropertyChange { LogId = logId, LogPropertyChangeId = LogPropertyChangeId, PropertyKey = property.Key, PreviousValue = originalValue, NewValue = currentValue, EncryptionKey = LogHelper.GetSHA1HashData(logId + LogPropertyChangeId.ToString() + property.Key + originalValue + currentValue) });
            //                        }
            //                        else
            //                            sb.AppendLine(string.Format("-The value of {0} was changed.", property.Name));
            //                    }
            //                }
            //                message = sb.ToString();
            //                break;
            //            case EntityState.Unchanged:
            //                break;
            //            default:
            //                break;
            //        }

            //        if (!string.IsNullOrWhiteSpace(message))
            //        {
            //            logs.Add(new Log
            //            {
            //                LogId = logId,
            //                ObjectId = objectId,
            //                ParentId = parentId,
            //                TypeKey = typeInfo.Key,
            //                OperationKey = entry.State.ToString(),
            //                UserId = userId,
            //                Representative = false,
            //                Message = message,
            //                Created = now,
            //                Processed = true,
            //                SendEmail = false,
            //                WriteAsFile = false
            //            });
            //        }
            //    }
            //}

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {

                    builder.Append(String.Format(CultureInfo.InvariantCulture, "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                       eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    builder.Append(Environment.NewLine);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        builder.Append(String.Format(CultureInfo.InvariantCulture, "- Property: \"{0}\", Error: \"{1}\", Value: \"{2}\"",
                            ve.PropertyName, ve.ErrorMessage, eve.Entry.Entity.GetType().GetProperty(ve.PropertyName).GetValue(eve.Entry.Entity)));
                        builder.Append(Environment.NewLine);
                    }

                }
                String filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Error/ErrorText.txt");
                Byte[] byteData = Encoding.ASCII.GetBytes(builder.ToString());
                using (FileStream oFileStream = new System.IO.FileStream(filepath, System.IO.FileMode.Append))
                {
                    oFileStream.Write(byteData, 0, byteData.Length);
                    //oFileStream.Close();
                }
                throw;
            }

        }


        public void SetModifiedState<T>(T t) where T : class
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        private IEnumerable<LogProperty> FieldsToLog(Type entityType)
        {
            if (this.AuditInfo == null)
                this.AuditInfo = new Dictionary<Type, List<LogProperty>>();

            if (!this.AuditInfo.ContainsKey(entityType))
            {

                var properties = this.Repository<LogProperty>().GetAll(a => a.TypeKey == entityType.Name).ToList();

                this.AuditInfo.Add(entityType, properties);

                //var auditPropertyInfo = new List<LogProperty>();
                //var auditFields = typeof(IAuditable).GetProperties().Select(x => x.Name).ToList();
                //foreach (var property in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                //{
                //	if (!property.GetGetMethod().IsVirtual)
                //		auditPropertyInfo.Add(property.Name);
                //}
                //this.AuditInfo.Add(entityType, auditPropertyInfo);
            }

            return this.AuditInfo[entityType];
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

