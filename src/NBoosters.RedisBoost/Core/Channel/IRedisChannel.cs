﻿#region Apache Licence, Version 2.0
/*
 Copyright 2013 Andrey Bulygin.

 Licensed under the Apache License, Version 2.0 (the "License"); 
 you may not use this file except in compliance with the License. 
 You may obtain a copy of the License at 

		http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software 
 distributed under the License is distributed on an "AS IS" BASIS, 
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 See the License for the specific language governing permissions 
 and limitations under the License.
 */
#endregion

using System;
using System.Net;
using System.Threading.Tasks;

namespace NBoosters.RedisBoost.Core.Channel
{
	internal interface IRedisChannel: ISocketDependent, ISerializerDependent, IDisposable
	{
		ClientState State { get; }

		Task<MultiBulk> MultiBulkCommand(byte[][] args);
		Task<string> StatusCommand(byte[][] args);
		Task<long> IntegerCommand(byte[][] args);
		Task<long?> IntegerOrBulkNullCommand(byte[][] args);
		Task<Bulk> BulkCommand(params byte[][] args);
		Task<RedisResponse> ExecuteRedisCommand(byte[][] args);

		Task SendDirectRequest(byte[][] args);
		Task<RedisResponse> ReadDirectResponse();

		Task Connect(EndPoint endPoint);
		Task Disconnect();

		void ResetState();
		void SwitchToOneWay();
		void SetQuitState();
	}
}
