using AppChat.Base;
using Application.Common.Mapping;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppChat.ToJson
{
    public class ConversationToJson
    {
        public int Id { get; set; }
        public string User1Name { get; set; }
        public string User2Name { get; set; }
        public List<MessageVM> Messages;
        public static string GetJson(Conversation con)
        {
            var cvm = new ConversationToJson();
            cvm.Id = con.Id;
            cvm.User1Name = con.User1Name;
            cvm.User2Name = con.User2Name;
            //we ask for count only once
            cvm.Messages = new List<MessageVM>();//initialize the list
            foreach (var message in con.Messages)//put all messages in the list
            {
                cvm.Messages.Add(new MessageVM(message));//convert them then add them
            }
            //sort all messages by date
            cvm.Messages.Sort((x, y) =>
            DateTime.Compare(
                (DateTime.Parse(x.Timestamp)), (DateTime.Parse(y.Timestamp)))
            );

            return JsonConvert.SerializeObject(cvm);
        }
    }
}
