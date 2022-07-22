using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        ProductsDal _productsDal = new ProductsDal();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productsDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productsDal.Add(new Product
            {
                Name = tbxNameAdd.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                Stock = Convert.ToInt32(tbxStockAdd.Text)
            });

            LoadProducts();

            MessageBox.Show("Product added!");

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUpdateUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateStock.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product 
            { 
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxUpdateName.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                Stock = Convert.ToInt32(tbxUpdateStock.Text)
            };

            _productsDal.Update(product);

            LoadProducts();

            MessageBox.Show("Updated!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            
            _productsDal.Delete(id);

            LoadProducts();

            MessageBox.Show("Deleted!");
        }
    }
}
