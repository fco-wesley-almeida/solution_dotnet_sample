using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Npgsql;

namespace CorteAutomatico.Tests;

public class Utils
{
    public static NpgsqlConnection Connection() => new(ConnectionStr());

    public static string ConnectionStr() => Environment.GetEnvironmentVariable("TESTS_DATABASE_CONNECTION_STRING")!;

    public static T RandomItem<T>(IEnumerable<T> enummerable)
    {
        var list = enummerable as T[] ?? enummerable.ToArray();
        int randomIndex = Faker.RandomNumber.Next(0, list.Length - 1);
        return list[randomIndex];
    }

    public static bool IsSortedBy<T>(IEnumerable<T> enummerable, Func<T,string> orderingCriterion) where T: class
    {
        var array = enummerable.ToArray();
        for (int i = 1; i < array.Length; i++)
        {
            if (string.Compare(orderingCriterion(array[i - 1]), orderingCriterion(array[i]), StringComparison.Ordinal) == 1)
            {
                return false;
            }
        }
        return true;
    }

    public static List<T> FakeList<T>(int length) where T: class
    {
        var list = new List<T>();
        for (int i = 0; i < length; i++)
        {
            list.Add(FakeObj<T>());
        }
        return list;
    }

    public static T FakeObj<T>() where T: class
    {
        T? obj = new Bogus.Faker<T>().Generate();
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            property.SetValue(obj, RandomValue(obj, property));
        }
        return obj;
    }

    private static dynamic? RandomValue<T>(T obj, PropertyInfo property)
    {
        Type type = property.PropertyType;
        object? value = property.GetValue(obj, null);
        if (type.IsPrimitive || type == typeof(string))
        {
            return RandomValue(type);
        }
        if (value is Guid)
        {
            return Guid.NewGuid();
        }
        if (value is DateTime)
        {
            return DateTime.Now
                .AddDays(Faker.RandomNumber.Next(-1000, 1000))
                .AddMinutes(Faker.RandomNumber.Next(0,1440))
                .AddSeconds(Faker.RandomNumber.Next(0,60))
            ;
        }
        // if (typeof(IEnumerable).IsAssignableFrom(type))
        // {
        //     Type listType = property.PropertyType.GetGenericArguments()[0];
        //     IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listType))!;
        //     for (int i = 0; i < Faker.RandomNumber.Next(1,1000); i++)
        //     {
        //         if (listType.IsPrimitive)
        //         {
        //             var randValue = RandomValue(listType);
        //             if (randValue is not null)
        //             {
        //                 list.Add(randValue);
        //             }
        //         }
        //     }
        //     return list;
        // }
        return null;
    }

    private static dynamic? RandomValue(Type type)
    {
        if (type == typeof(int))
        {
            return new Random().Next();
        }
        if (type == typeof(string))
        {
            return RandomString(1, 100);
        }
        if (type == typeof(bool))
        {
            return Faker.Boolean.Random();
        }
        if (type == typeof(decimal))
        {
            return Convert.ToDecimal(Faker.RandomNumber.Next() / 10);
        }
        return null;
    }

    public static string RandomString(int minLength, int maxLength)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, Faker.RandomNumber.Next(1,100))
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}