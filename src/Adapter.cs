using Atomus.Diagnostics;
using System;
using System.Windows;

namespace Atomus.Windows.MessageBox
{
    public class Adapter : IMessageBox
    {
        private static IMessageBox messageBox;
        
        public Adapter()
        {
            if (messageBox == null)
            {
                try
                {
                    messageBox = (IMessageBox)this.CreateInstance("MessageBox");
                }
                catch (AtomusException exception)
                {
                    DiagnosticsTool.MyTrace(exception);
                    messageBox = new WindowsMessageBox();
                }
                catch (Exception exception)
                {
                    DiagnosticsTool.MyTrace(exception);
                    messageBox = new WindowsMessageBox();
                }
            }
        }

        MessageBoxResult IMessageBox.Show(string text, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, args) :
                        System.Windows.MessageBox.Show(text.Translate(args));
        }
        MessageBoxResult IMessageBox.Show(string text, string caption, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, caption, args) :
                        System.Windows.MessageBox.Show(text.Translate(args), caption.Translate());
        }
        MessageBoxResult IMessageBox.Show(string text, string caption, MessageBoxButton button, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, caption, button, args) :
                        System.Windows.MessageBox.Show(text.Translate(args), caption.Translate(), button);
        }
        MessageBoxResult IMessageBox.Show(string text, string caption, MessageBoxButton button, MessageBoxImage icon, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, caption, button, icon, args) :
                        System.Windows.MessageBox.Show(text.Translate(args), caption.Translate(), button, icon);
        }
        MessageBoxResult IMessageBox.Show(string text, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, caption, button, icon, defaultResult, args) :
                        System.Windows.MessageBox.Show(text.Translate(args), caption.Translate(), button, icon, defaultResult);
        }
        MessageBoxResult IMessageBox.Show(string text, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(text, caption, button, icon, defaultResult, options, args) :
                        System.Windows.MessageBox.Show(text.Translate(args), caption.Translate(), button, icon, defaultResult, options);
        }
        MessageBoxResult IMessageBox.Show(AtomusException exception)
        {
            return (messageBox != null) ? messageBox.Show(exception) :
                System.Windows.MessageBox.Show(exception.Message, exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        MessageBoxResult IMessageBox.Show(Exception exception)
        {
            if (messageBox != null)
                return messageBox.Show(exception);
            else
            {
                if (exception.InnerException != null)
                    return System.Windows.MessageBox.Show(exception.InnerException.Message, exception.InnerException.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    return System.Windows.MessageBox.Show(exception.Message, exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        MessageBoxResult IMessageBox.Show(Window owner, string text, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args));
        }
        MessageBoxResult IMessageBox.Show(Window owner, string text, string caption, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, caption, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args), caption.Translate());
        }
        MessageBoxResult IMessageBox.Show(Window owner, string text, string caption, MessageBoxButton button, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, caption, button, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args), caption.Translate(), button);
        }
        MessageBoxResult IMessageBox.Show(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage icon, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, caption, button, icon, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args), caption.Translate(), button, icon);
        }
        MessageBoxResult IMessageBox.Show(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, caption, button, icon, defaultResult, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args), caption.Translate(), button, icon, defaultResult);
        }
        MessageBoxResult IMessageBox.Show(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options, params string[] args)
        {
            return (messageBox != null) ? messageBox.Show(owner, text, caption, button, icon, defaultResult, options, args) :
                        System.Windows.MessageBox.Show(owner, text.Translate(args), caption.Translate(), button, icon, defaultResult, options);
        }
        MessageBoxResult IMessageBox.Show(Window owner, AtomusException exception)
        {
            return (messageBox != null) ? messageBox.Show(exception) :
                System.Windows.MessageBox.Show(owner, exception.Message, exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        MessageBoxResult IMessageBox.Show(Window owner, Exception exception)
        {
            if (messageBox != null)
                return messageBox.Show(owner, exception);
            else
            {
                if (exception.InnerException != null)
                    return System.Windows.MessageBox.Show(owner, exception.InnerException.Message, exception.InnerException.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    return System.Windows.MessageBox.Show(owner, exception.Message, exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}