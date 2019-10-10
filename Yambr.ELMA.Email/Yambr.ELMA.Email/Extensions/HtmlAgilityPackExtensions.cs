﻿using HtmlAgilityPack;

namespace Yambr.ELMA.Email.Extensions
{
    internal static class HtmlAgilityPackExtensions
    {

        //here's the extension method I use
        public static HtmlNodeCollection SafeSelectNodes(this HtmlNode node, string selector)
        {
            return (node.SelectNodes(selector) ?? new HtmlNodeCollection(node));
        }
    }
}
