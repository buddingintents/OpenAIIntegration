using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAIIntegration
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool exitNow = false;
            OpenAIAPI api = new OpenAIAPI(@"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");
            string response;
            var chat = api.Chat.CreateConversation();
            string readResponse;

            /// give instruction as System
            Console.WriteLine("If you have System message. Press Y else any other key");
            readResponse = Console.ReadLine().ToString();
            if (readResponse.ToUpper() == "Y")
            {
                Console.Write("system:");
                chat.AppendSystemMessage(Console.ReadLine());
                Console.WriteLine($"{chat.Messages[0].Role}: {chat.Messages[0].Content}");
            }
            while (!exitNow)
            {
                Console.Write("USER:");
                chat.AppendUserInput(Console.ReadLine());
                response = await chat.GetResponseFromChatbot();
                chat.AppendExampleChatbotOutput(response);
                Console.WriteLine($"{chat.Messages[chat.Messages.Count - 1].Role}: {chat.Messages[chat.Messages.Count - 1].Content}");
                Console.WriteLine("Press X to exit");
                readResponse = Console.ReadLine().ToString();
                if (readResponse.ToUpper() == "X")
                    exitNow = true;
            }
        }
    }
}
