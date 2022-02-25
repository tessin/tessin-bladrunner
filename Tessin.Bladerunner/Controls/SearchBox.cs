﻿using LINQPad.Controls;
using System;

namespace Tessin.Bladerunner.Controls
{
    public class SearchBox : Div, ITextControl
    {
        private readonly TextBox _textBox;

        //private Action<SearchBox> _externalOpenAction;

        //private Action _externalClearAction;

        //private Hyperlink _externalOpen;

        public SearchBox(string initialText = "", string placeholder = "Search", ContextMenu contextMenu = null)
        {
            _textBox = new TextBox(initialText);
            if (!string.IsNullOrEmpty(placeholder))
            {
                _textBox.HtmlElement.SetAttribute("placeholder", placeholder);
            }
            _textBox.TextInput += (sender, args) =>
            {
                TextInput?.Invoke(sender, args);
            };

            this.SetClass("search-box");

            this.VisualTree.Add(_textBox);

            this.VisualTree.Add(new Icon(Icons.Magnify));

            //if (contextMenu != null)
            //{
            //    children.Add(contextMenu);
            //}

            //var externalClear = new IconButton(Icons.Close, (_) =>
            //{
            //    _externalClearAction?.Invoke();
            //    _textBox.Enabled = true;
            //});
            //externalClear.AddClass("external-clear");
            //VisualTree.Add(externalClear);

            //_externalOpen = new Hyperlink("Query", (_) => _externalOpenAction?.Invoke(this));
            //_externalOpen.AddClass("external-open");
        }

        /*
        public void SetExternal(string title, Action<SearchBox> onClick)
        {
            _externalOpen.Text = title;
            _container.CssChildRules[".external-open", "display"] = "block";
            _container.CssChildRules[".external-clear", "display"] = "block";
            _container.CssChildRules[".flexbox INPUT:-ms-input-placeholder", "color"] = "transparent !important";
            _externalOpenAction = onClick;
            _textBox.Enabled = false;
        }
        */

        public void SelectAll()
        {
            _textBox.SelectAll();
        }

        public string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public event EventHandler TextInput;
    }
}
