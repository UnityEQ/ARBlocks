#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_LOAD_BLOCKS : GSTypedRequest<LogEventRequest_LOAD_BLOCKS, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_LOAD_BLOCKS() : base("LogEventRequest"){
			request.AddString("eventKey", "LOAD_BLOCKS");
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_name( string value )
		{
			request.AddString("name", value);
			return this;
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_lat( string value )
		{
			request.AddString("lat", value);
			return this;
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_lon( string value )
		{
			request.AddString("lon", value);
			return this;
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_alt( string value )
		{
			request.AddString("alt", value);
			return this;
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_type( string value )
		{
			request.AddString("type", value);
			return this;
		}
		
		public LogEventRequest_LOAD_BLOCKS Set_health( string value )
		{
			request.AddString("health", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_LOAD_BLOCKS : GSTypedRequest<LogChallengeEventRequest_LOAD_BLOCKS, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_LOAD_BLOCKS() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "LOAD_BLOCKS");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_LOAD_BLOCKS SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_name( string value )
		{
			request.AddString("name", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_lat( string value )
		{
			request.AddString("lat", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_lon( string value )
		{
			request.AddString("lon", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_alt( string value )
		{
			request.AddString("alt", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_type( string value )
		{
			request.AddString("type", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_BLOCKS Set_health( string value )
		{
			request.AddString("health", value);
			return this;
		}
	}
	
	public class LogEventRequest_SAVE_BLOCKS : GSTypedRequest<LogEventRequest_SAVE_BLOCKS, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SAVE_BLOCKS() : base("LogEventRequest"){
			request.AddString("eventKey", "SAVE_BLOCKS");
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_name( string value )
		{
			request.AddString("name", value);
			return this;
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_lat( string value )
		{
			request.AddString("lat", value);
			return this;
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_lon( string value )
		{
			request.AddString("lon", value);
			return this;
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_alt( string value )
		{
			request.AddString("alt", value);
			return this;
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_type( string value )
		{
			request.AddString("type", value);
			return this;
		}
		
		public LogEventRequest_SAVE_BLOCKS Set_health( string value )
		{
			request.AddString("health", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_SAVE_BLOCKS : GSTypedRequest<LogChallengeEventRequest_SAVE_BLOCKS, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SAVE_BLOCKS() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SAVE_BLOCKS");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SAVE_BLOCKS SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_name( string value )
		{
			request.AddString("name", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_lat( string value )
		{
			request.AddString("lat", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_lon( string value )
		{
			request.AddString("lon", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_alt( string value )
		{
			request.AddString("alt", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_type( string value )
		{
			request.AddString("type", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_BLOCKS Set_health( string value )
		{
			request.AddString("health", value);
			return this;
		}
	}
	
}
	

namespace GameSparks.Api.Messages {


}
