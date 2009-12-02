using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class ShoppingCart
{
    public class Item
    {
        private Int64 m_EventId;
        public Int64 EventId
        {
            get
            {
                return m_EventId;
            }

            set
            {
                m_EventId = value;
            }
        }
        
        private String m_EventName;
        public String EventName
        {
            get
            {
                return m_EventName;
            }

            set
            {
                m_EventName = value;
            }
        }
        
        private decimal m_EventPrice;
        public decimal EventPrice
        {
            get
            {
                return m_EventPrice;
            }

            set
            {
                m_EventPrice = value;
            }
        }
        
        private int m_Quantity;
        public int Quantity
        {
            get
            {
                return m_Quantity;
            }

            set
            {
                m_Quantity = value;
            }
        }
    }

    public class ShippingInfo
    {
        private String m_FirstName;
        public String FirstName
        {
            get
            {
                return m_FirstName;
            }
            set
            {
                m_FirstName = value;
            }
        }

        private String m_LastName;
        public String LastName
        {
            get
            {
                return m_LastName;
            }
            set
            {
                m_LastName = value;
            }
        }

        private String m_Address;
        public String Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }

        private String m_City;
        public String City
        {
            get
            {
                return m_City;
            }
            set
            {
                m_City = value;
            }
        }

        private String m_PostCode;
        public String PostCode
        {
            get
            {
                return m_PostCode;
            }
            set
            {
                m_PostCode = value;
            }
        }

        private String m_Country;
        public String Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

        private String m_Email;
        public String Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        private String m_Phone;
        public String Phone
        {
            get
            {
                return m_Phone;
            }
            set
            {
                m_Phone = value;
            }
        }
    }

    public SerializableDictionary<Int64, Item> cart = new SerializableDictionary<Int64, Item>();

    public ShippingInfo shippingInfo = new ShippingInfo();

    private Item getItem(Int64 eventId)
    {
        return cart[eventId];
    }

    public void addItem(Int64 eventId, String eventName, decimal eventPrice, int quantity)
    {
        if (eventId < 0 || eventName == null || eventPrice < 0 || quantity < 1)
        {
            return;
        }
        else
        {
            if (cart.ContainsKey(eventId))
            {
                updateItem(eventId, quantity + cart[eventId].Quantity);
            }
            else
            {
                Item newItem = new Item();
                newItem.EventId = eventId;
                newItem.EventName = eventName;
                newItem.EventPrice = eventPrice;
                newItem.Quantity = quantity;
                cart.Add(eventId, newItem);
            }
        }
    }

    public void updateItem(Int64 eventId, int quantity)
    {
        cart[eventId].Quantity = quantity;
    }

    public void removeItem(Int64 eventId)
    {
        cart.Remove(eventId);
    }

    public void removeAllItems()
    {
        List<Int64> keys = new List<Int64>(cart.Keys);
        foreach (Int64 key in keys)
        {
            cart.Remove(key);
        }
    }

    public List<Item> getItems()
    {
        //List<Item> list = new List<Item>(cart.Values);
        
        return new List<Item>(cart.Values);
    }
	
    public ShippingInfo getShippingInfo()
    {
        return shippingInfo;
    }

    public void setShippingInfo(ShippingInfo shippingInfo)
    {
        this.shippingInfo = shippingInfo;
    }
    public decimal getTotalNetPrice()
    {
		decimal total = 0;
		foreach(Item item in this.getItems())
		{
			total += item.EventPrice * item.Quantity;
		}
		return total;
    }
}