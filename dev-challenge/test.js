fetch("https://images.tcdn.com.br/dev-challenge/cart/kobq972itl2rqugoa5v2k7e3j7.json")
  .then(function (response) {
    return response.json();
  })
  .then(function (dados) {
    dados.forEach(carrinho => {
      const carrinhoo = carrinho.Cart
      console.log(carrinhoo)

      const preco = carrinhoo.price
      const nome_produto = carrinhoo.product_name
      const email = carrinhoo.email
      const imagem = carrinhoo.product_image.https


      document.body.innerHTML += '<div class="card"> <div class="imagem"><img src="' +imagem+ '"></div><p class="nome">' +nome_produto+ '</p> <p class="preco">' +preco+ '</p><p class="finalize">finalize sua compra ate 22/04/2024 para obter 50% de desconto!</p> </div>'
    });
    


  }) 

