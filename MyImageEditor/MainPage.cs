using Reflection.Interfaces;
using Reflection.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MyImageEditor
{
    public partial class MainPage : Form
    {
        private readonly Dictionary<string, IFilter> _filters;

        public MainPage()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var folder = Path.GetDirectoryName(assembly.Location);

            var pluginManager = new PluginManager();
            _filters = pluginManager.LoadFilters(folder);

            CreateFilterMenu();
        }

        private void CreateFilterMenu()
        {
            pluginsToolStripMenuItem.DropDownItems.Clear();

            foreach (var pair in _filters)
            {
                var item = new ToolStripMenuItem(pair.Key);
                item.Click += menuItem_Click;
                pluginsToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private async void menuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                var filter = _filters[menuItem.Text];

                try
                {
                    Cursor = Cursors.WaitCursor;
                    pictureBox1.Image = await filter.RunPluginAsync(pictureBox1.Image);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }

            Cursor = Cursors.Default;
        }
    }
}