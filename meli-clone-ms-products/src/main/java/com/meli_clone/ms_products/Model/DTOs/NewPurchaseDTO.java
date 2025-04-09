package com.meli_clone.ms_products.Model.DTOs;


import jakarta.validation.Valid;
import jakarta.validation.constraints.NotEmpty;

import java.util.List;

public class NewPurchaseDTO {

    @NotEmpty
    private List<@Valid PurchaseItemDTO> items;

    public List<PurchaseItemDTO> getItems() {
        return items;
    }
}
