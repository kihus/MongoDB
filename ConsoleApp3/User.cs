using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;

public class User
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string Login { get; set; }
	public string Password { get; set; }

	[BsonRepresentation(BsonType.DateTime)]
	public DateTime CreatedAt { get; set; }

	[BsonRepresentation(BsonType.DateTime)]
	public DateTime UpdateAt { get; set; }
	public bool IsActive { get; set; }

	public User(string login, string password)
	{
		Login = login;
		Password = password;
		CreatedAt = DateTime.UtcNow;
		UpdateAt = DateTime.UtcNow;
		IsActive = true;
	}

	public override string ToString()
	{
		return $"\nid: {Id}\nLogin: {Login}\nPassword: {Password}\nCreated at: {CreatedAt:d}\nUpdated at: {UpdateAt}\nSituation: {IsActive}\n---";
	}

}