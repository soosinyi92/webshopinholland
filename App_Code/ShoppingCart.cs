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

    public SerializableDictionary<Int64, Item> cart = new SerializableDictionary<Int64, Item>();

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

    public List<Item> getItems()
    {
        List<Item> list = new List<Item>(cart.Values);
        
        return list;
    }
}