using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

namespace App7.Firebase
{
    class FireBaseConnect
    {
       private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "oRUbqWfStvSooA9A1B1DmKCNpHR4Ax2MzPqULQsQ", //ключ доступа к базе данных
            BasePath = "https://heartclinic.firebaseio.com/" //адрес доступа
        };
        private IFirebaseClient client;

       public FireBaseConnect() {
            client = new FirebaseClient(config);
        }
        public async Task<string> Get(string path) {
             FirebaseResponse response = await client.GetAsync(path);
            return response.Body;
        }
        public async Task<User> GetUser(string path)
        {
            FirebaseResponse response = await client.GetAsync(path);
            User user = response.ResultAs<User>();
            return user;
        }

        public async Task<User> Update(string path, Dictionary<string,string> values)
        {
            FirebaseResponse response = await client.UpdateAsync(path, values);
            User user = response.ResultAs<User>();
            return user;
        }
        public async void Update(string path, string key, string value)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(key, value);
            FirebaseResponse response = await client.UpdateAsync(path, values);
        }
    }
}
