﻿using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace StackExchange.Chat.Actions.Message
{
	public class MessageEditor : ChatAction
	{
		private readonly int messageId;

		internal override Method RequestMethod => Method.POST;

		internal override string Endpoint => $"https://{Host}/messages/{messageId}";

		internal override bool RequiresFKey => true;

		internal override bool RequiresAuthCookies => true;

		internal override ActionPermissionLevel RequiredPermissionLevel => ActionPermissionLevel.Anyone;



		public MessageEditor(int messageId, string text)
		{
			if (messageId < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(messageId));
			}

			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException($"'{nameof(text)}' cannot be null or empty.");
			}

			this.messageId = messageId;

			Data = new Dictionary<string, object>
			{
				["text"] = text
			};
		}



		internal override object ProcessResponse(HttpStatusCode status, string response)
		{
			return status == HttpStatusCode.OK &&
				response?.ToUpperInvariant() == "\"OK\"";
		}
	}
}
