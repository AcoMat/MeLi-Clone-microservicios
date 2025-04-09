package com.meli_clone.ms_products.Model.Entities;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

@Getter
@Entity
public class PurchaseItem  {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private Long productId;
    private Double priceAtPurchase;
    private int quantity;
    @Setter
    @ManyToOne
    @JoinColumn(name = "purchase_id")
    private Purchase purchase;

    public PurchaseItem() {
    }

    public PurchaseItem(Long productId, Double priceAtPurchase, int quantity) {
        this.productId = productId;
        this.priceAtPurchase = priceAtPurchase;
        this.quantity = quantity;
    }

}
