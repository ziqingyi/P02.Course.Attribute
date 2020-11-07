using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Init;

namespace P28.Course.Redis.Interface
{
    /// <summary>
    /// base class of Redis operation, implement IDisposable, mainly used for free up memory.
    /// </summary>
    public abstract class RedisBase:IDisposable
    {
        public IRedisClient iClient { get; private set; }

        public RedisBase()
        {
            iClient = RedisManager.GetClient();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    iClient.Dispose();
                    iClient = null;
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Transaction()
        {
            using (IRedisTransaction irt = this.iClient.CreateTransaction())
            {
                try
                {
                    irt.QueueCommand(r =>r.Set("key",20));
                    irt.QueueCommand(r=>r.Increment("key",1));
                    irt.Commit();
                }
                catch (Exception ex)
                {
                    irt.Rollback();
                    throw;
                }
            }
        }

        //clear all data, please be aware
        public virtual void FlushAll()
        {
            iClient.FlushAll();
        }

        //save data to hard drive
        public void Save()
        {
            iClient.Save();//blocking way of saving
        }

        // save data to hard drive asynchronous  
        public void SaveAsync()
        {
            iClient.SaveAsync();
        }
    }
}
