namespace SwiftCart.Models
{
    public enum UserRole
    {
        Customer = 0,
        StoreOwner = 1,
        Rider = 2,
        Admin = 3
    }

    public enum StoreStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Suspended = 3,
        Closed = 4
    }

    public enum ProductStatus
    {
        Active = 0,
        Inactive = 1,
        OutOfStock = 2
    }

    public enum OrderStatus
    {
        Pending = 0,
        Confirmed = 1,
        Preparing = 2,
        ReadyForPickup = 3,
        RiderAssigned = 4,
        PickedUp = 5,
        InTransit = 6,
        Delivered = 7,
        Cancelled = 8,
        Failed = 9
    }

    public enum PaymentStatus
    {
        Pending = 0,
        Processing = 1,
        Paid = 2,
        Failed = 3,
        Refunded = 4,
        Cancelled = 5
    }

    public enum PaymentMethod
    {
        MobileMoney = 0,
        CashOnDelivery = 1,
        Card = 2
    }

    public enum DeliveryStatus
    {
        WaitingForRider = 0,
        Assigned = 1,
        PickedUp = 2,
        InTransit = 3,
        Delivered = 4,
        Cancelled = 5
    }

    public enum DeliveryTrackingStatus
    {
        Assigned = 0,
        AtStore = 1,
        PickedUp = 2,
        InTransit = 3,
        NearCustomer = 4,
        Delivered = 5
    }

    public enum VehicleType
    {
        Motorcycle = 0,
        Bicycle = 1,
        Car = 2,
        Other = 3
    }

    public enum RiderApprovalStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Suspended = 3
    }

    public enum NotificationType
    {
        General = 0,
        Order = 1,
        Delivery = 2,
        Payment = 3,
        Promotion = 4,
        Review = 5,
        System = 6
    }
}

