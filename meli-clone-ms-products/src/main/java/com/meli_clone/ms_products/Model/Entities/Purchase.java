package com.meli_clone.ms_products.Model.Entities;

import jakarta.persistence.*;
import lombok.Getter;

import java.time.Instant;
import java.util.List;

@Getter
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

    public Purchase() {
    }

    public Purchase(Long userId, Instant purchaseDate, int quantity, List<PurchaseItem> items, Double totalPrice) {
        this.userId = userId;
        this.purchaseDate = purchaseDate;
        this.quantity = quantity;
        this.items = items.stream().peek(item -> item.setPurchase(this)).toList();
        this.totalPrice = totalPrice;
    }

}
