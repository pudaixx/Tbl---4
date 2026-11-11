namespace Exercicio_Windows_Forms_GitHub;

public class Form3 : Form
{
    public Form3()
    {
        Text = "Produtos";
        Size = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(new Label
        {
            Text = "Formulário de Produtos",
            AutoSize = true,
            Location = new Point(30, 30)
        });
    }
}
