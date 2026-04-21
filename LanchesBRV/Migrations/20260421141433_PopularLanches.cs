using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesBRV.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                "VALUES('Lanche Natural', 'Lanche feito com ingredientes integrais e naturais', 'Lanche preparado com pão integral macio e fresco, recheado com peito de frango desfiado temperado, alface crocante, tomate selecionado e cenoura ralada.', 14.99, '/images/lanches/lanche-natural-1.jpg', '/images/lanches/lanche-natural-thumb.jpg', 1, 1, 2 )");

            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                "VALUES('X-Burger', 'Clássico hambúrguer com queijo', 'Pão macio com hambúrguer grelhado suculento, queijo derretido, alface fresca, tomate e molho especial da casa, proporcionando um sabor tradicional e irresistível.', 18.90, '/images/lanches/x-burger.jpg', '/images/lanches/x-burger-thumb.jpg', 0, 1, 1 )");

            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                "VALUES('X-Salada', 'Hambúrguer com salada completa', 'Delicioso hambúrguer grelhado com queijo, alface crocante, tomate fresco, milho e maionese especial, trazendo equilíbrio entre sabor e leveza.', 20.50, '/images/lanches/x-salada.jpg', '/images/lanches/x-salada-thumb.jpg', 0, 1, 1 )");

            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                "VALUES('Sanduíche Natural de Atum', 'Opção leve com atum e vegetais', 'Preparado com pão integral fresco, recheado com atum temperado, cenoura ralada, alface e tomate, oferecendo uma opção saudável, nutritiva e saborosa.', 16.75, '/images/lanches/sanduiche-atum.jpg', '/images/lanches/sanduiche-atum-thumb.jpg', 0, 1, 2 )");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
