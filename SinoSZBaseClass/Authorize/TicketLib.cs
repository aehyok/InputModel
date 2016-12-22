using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Authorize;

namespace SinoSZBaseClass.Authorize
{
	public class TicketLib
	{
		public static Dictionary<string, SinoSZTicketInfo> _tickets = new Dictionary<string, SinoSZTicketInfo>();
		public static bool CheckUserTicket(SinoSZTicketInfo _tinfo)
		{
			string _uTicket = _tinfo.Ticket;
			if (_tickets.ContainsKey(_uTicket))
			{
				SinoSZTicketInfo _cacheinfo = _tickets[_uTicket];
				if (_cacheinfo.Name == _tinfo.Name && _cacheinfo.Address == _tinfo.Address)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public static string AddTicket(string _uname, string _uaddr)
		{
			string _ticket = Guid.NewGuid().ToString();
			AddTicket(_uname, _uaddr, _ticket);
			return _ticket;
		}

		public static void AddTicket(string _uname, string _uaddr, string _ticket)
		{
			SinoSZTicketInfo _uinfo = new SinoSZTicketInfo(_uname, _uaddr, _ticket);
			if (_tickets.ContainsKey(_ticket))
			{
				_tickets[_ticket] = _uinfo;
			}
			else
			{
				_tickets.Add(_ticket, _uinfo);
			}
		}

		public static void Clear()
		{
			_tickets.Clear();
		}
	}
}
