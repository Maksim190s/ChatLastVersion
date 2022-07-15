using System;
using System.Text.Json;

namespace ChatProgramm
{
	public class ChatRepository
	{
		public Chat LoadChat (string path, User[] users)
		{
			var chatText = File.ReadAllText(path);
            var rawMessages = JsonSerializer.Deserialize<List<Message>>(chatText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true});
//Этот момент не понимаю. 
//У меня свойство Пользователи в чате пустое(намеренно). Я хотел их подгрузить отдельно, так как они вынесены в отдельную базу данных и загружаются перед тем как выгрузить чат.
//Если все данные хранить в одном файле, то я эту проблему смогу решить, добавив в Chat.json пользователей. 
//Но кажется логичнее хранить разные типы данных в разных базах, чтоб при необходимости воспользоваться конкретной базой.
//Получается нужно отдельно создать БД Messages, или все таки можно совместить неполный чат(сообщения с лайками) и массив пользователей?
//Попытался так, но не получилось:
			/* 1.
			var chat = JsonSerializer.Deserialize<Chat>(chatText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true});
			chat.Users.Append(users);
			   2.
			Еще кажется, что можно инициализировать чат используя this. - но я не знаю синтаксис.
			*/
            // CHAT
			var mainChat = new Chat(rawMessages.ToArray(), users);
            return mainChat;
		}
    }
}


