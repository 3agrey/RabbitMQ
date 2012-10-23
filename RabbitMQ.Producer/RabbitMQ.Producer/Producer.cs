using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    class Start
    {
        public static void Main()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("start", false, false, false, null);

                string message = "!";
                byte[] body = System.Text.Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "start", null, body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

    }
}