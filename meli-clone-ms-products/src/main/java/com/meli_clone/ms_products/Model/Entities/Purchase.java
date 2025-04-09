package com.meli_clone.ms_products.Model.Entities;

import jakarta.persistence.*;

import java.math.BigDecimal;
import java.time.Instant;
import java.util.List;

@Entity
public class Purchase{
    @Id
    @GeneratedValue(strategy = jakarta.persistence.GenerationType.IDENTITY)
    private Long purchaseId;

    private Long userId;

    private Instant purchaseDate;

    private int quantity;

    @OneToMany(mappedBy = "purchase", cascade = CascadeType.ALL)
    private List<PurchaseItem> items;

    private Double totalPrice;


    public Purchase(Long userId, Instant purchaseDate, int quantity, List<PurchaseItem> items, Double totalPrice) {
        this.userId = userId;
        this.purchaseDate = purchaseDate;
        this.quantity = quantity;
        this.items = items;
        this.totalPrice = totalPrice;
    }

    public Long getPurchaseId() {
        return purchaseId;
    }

    public Long getUserId() {
        return userId;
    }

    public Instant getPurchaseDate() {
        return purchaseDate;
    }

    public int getQuantity() {
        return quantity;
    }

    public List<PurchaseItem> getItems() {
        return items;
    }

    public Double getTotalPrice() {
        return totalPrice;
    }
}
