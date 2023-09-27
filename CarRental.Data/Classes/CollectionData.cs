﻿using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public CollectionData() => SeedData();

    void SeedData()
    {
        _persons.Add(new Customer(12345, "Doe", "John"));
        _persons.Add(new Customer(98765, "Doe", "Jane"));

        _vehicles.Add(new Car(1, "ABC123", "Volvo", 10000, VehicleTypes.Combi, 1, 200));
        _vehicles.Add(new Car(2, "DEF456", "Saab", 20000, VehicleTypes.Sedan, 1, 100));
        _vehicles.Add(new Car(3, "GHI789", "Tesla", 1000, VehicleTypes.Sedan, 3, 100));
        _vehicles.Add(new Car(4, "JKL012", "Jeep", 5000, VehicleTypes.Van, 1.5, 300));
        _vehicles.Add(new Motorcycle(5, "MNO345", "Yamaha", 30000, VehicleTypes.Motorcycle, 0.5, 50));

        _bookings.Add(new Booking(_vehicles[0], _persons[0], new DateOnly(2023, 9, 9)));
        _bookings.Add(new Booking(_vehicles[1], _persons[1], new DateOnly(2023, 9, 10), 100, new DateOnly(2023, 9, 11)));

    }
    
    
    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        if (status is 0)
            return _vehicles;
        else
            return _vehicles.Where(v => v.VehicleStatus.Equals(status));
    }
    public IEnumerable<IBooking> GetBookings() => _bookings;
}