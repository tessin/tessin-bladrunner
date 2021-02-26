﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQPad;
using LINQPad.Controls;

namespace Tessin.Bladerunner.Controls
{
    public class MenuButton : DumpContainer
    {
        public MenuButton(
            string label, 
            Action<Button> onClick, 
            string svgIcon = null,
            string tooltip = null,
            Task<object> pillTask = null,
            IconButton[] actions = null)
        {
            List<Control> children = new List<Control>();
            
            var button = new Button(null, onClick);
            if (tooltip != null)
            {
                button.HtmlElement.SetAttribute("title", tooltip);
            }
            button.HtmlElement.InnerHtml = $@"{svgIcon}<span>{label}</span>";
            children.Add(button);

            var pillContainer = new DumpContainer();
            children.Add(pillContainer);

            pillTask?.ContinueWith(e =>
            {
                if (e.Result != null)
                {
                    var span = new Span(e.Result.ToString());
                    span.SetClass("menu-button--pill");
                    pillContainer.Content = span;
                }
                else
                {
                    pillContainer.Content = "";
                }
                
            }).ConfigureAwait(false);

            if (actions != null)
            {
                var divActions = new Div(
                    actions.Cast<Control>()
                );
                divActions.SetClass("menu-button--actions");

                JavascriptHelpers.ShowOnMouseOver(button, divActions, pillContainer);
                children.Add(divActions);
            }

            var divContainer = new Div(children);
            divContainer.SetClass("menu-button");

            this.Content = new Div(divContainer);
        }
    }
}