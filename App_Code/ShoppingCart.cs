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

    public List<Item> cart = new List<Item>();

    private Item getItem(Int64 eventId)
    {
        foreach (Item item in cart)
        {
            if (item.EventId == eventId)
                return item;
        }
        return null;
    }

    public void addOrUpdateItem(Int64 eventId, String eventName, decimal eventPrice, int quantity)
    {
        if (eventId < 0 || eventName == null || eventPrice < 0 || quantity < 1)
        {
            return;
        }
        else
        {
            int n = 0;
            foreach(Item item in cart)
            {
                n++;
                if (item.EventId == eventId)
                {
                    if (quantity == 0)
                    {
                        cart.RemoveAt(n);
                        return;
                    }
                    item.Quantity = quantity;
                    return;
                }
            }
            Item newItem = new Item();
            newItem.EventId = eventId;
            newItem.EventName = eventName;
            newItem.EventPrice = eventPrice;
            newItem.Quantity = quantity;
            cart.Add(newItem);
        }
    }

    public void removeItem(Int64 eventId)
    {
        int n = 0;
        foreach (Item item in cart)
        {
            n++;
            if (item.EventId == eventId)
            {
                cart.RemoveAt(n);
                return;
            }
        }
    }

    public List<Item> getItems()
    {
        return cart;
    }
}