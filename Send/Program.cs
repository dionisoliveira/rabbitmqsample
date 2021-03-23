using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            


            // Definição de fila.
            // queue: nome 
            channel.QueueDeclare(queue: "hello", //name bindingin to pool of message.
                                 durable: true,
                                 exclusive: false,//this queue is consuming in excluise worker? 
                                 autoDelete: false,
                                 arguments: null);

            string message = "New messagem for rabbitmq";
            var body = Encoding.UTF8.GetBytes(message);

            //add new properties in configuration queue message



             /*With props
            //IBasicProperties props = channel.CreateBasicProperties(); 
           // props.ContentType = "text/json"; // Adiciona o tipo de dado

            // Adiciona o tipo de persistência do objeto. 
            // 1 for "transient" / 2 for "persistent". 
           //   props.DeliveryMode = 2; 


            channel.BasicPublish( "amq.fanout",//Name exchange you send thee message
                                  "0001",//route queue
                                 props,
                                  body);
                                  */
// Basic Send messag
                                     channel.BasicPublish(exchange: "",
                                 routingKey: "samplename",
                                 basicProperties: null,
                                 body: body);
                                 
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}

