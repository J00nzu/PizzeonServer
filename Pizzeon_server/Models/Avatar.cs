﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Pizzeon_server.Models {
	public class Avatar : PurchaseableItem {
		[BsonId]
		public string Id { get; set; }
		public string Name { get; set;}
		public int Price { get; set;}
	}
}
