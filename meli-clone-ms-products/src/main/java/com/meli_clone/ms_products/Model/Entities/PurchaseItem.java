package com.meli_clone.ms_products.Model.Entities;

import jakarta.persistence.*;

@Entity
public class PurchaseItem  {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private Long productId;
    private Double priceAtPurchase;
    private int quantity;
    @ManyToOne
    @JoinColumn(name = "purchase_id")
    private Purchase purchase;

    public PurchaseItem(Long productId, Double priceAtPurchase, int quantity) {
        this.productId = productId;
        this.priceAtPurchase = priceAtPurchase;
        this.quantity = quantity;
    }

    public Long getId() {
        return id;
    }

    public Long getProductId() {
        return productId;
    }

    public Double getPriceAtPurchase() {
        return priceAtPurchase;
    }

    public int getQuantity() {
        return quantity;
    }

    public Purchase getPurchase() {
        return purchase;
    }
}
