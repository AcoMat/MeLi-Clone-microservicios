package com.meli_clone.ms_products.Service;

import com.meli_clone.ms_products.Mappers.Mapper;
import com.meli_clone.ms_products.Model.DTOs.NewPurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseItemDTO;
import com.meli_clone.ms_products.Model.Entities.Purchase;
import com.meli_clone.ms_products.Model.Entities.PurchaseItem;
import com.meli_clone.ms_products.Repository.PurchaseRepository;
import com.meli_clone.ms_products.Security.JWTValidator;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;

@Service
public class PurchaseService {
    @Autowired private PurchaseRepository purchaseRepository;
    @Autowired private Mapper mapper;
    @Autowired private JWTValidator jwtValidator;

    public PurchaseDTO registerPurchase(NewPurchaseDTO purchaseDTO, String token) {
        // Validar el token y obtener el userId del claim "SID"
        Long userId = jwtValidator.validateTokenAndGetSID(token);

        //Seteo fecha actual
        Instant actualDate = Instant.now();

        //Calculo precio total
        double totalPrice = purchaseDTO.getItems().stream()
                .mapToDouble(item -> item.getPrice() * item.getQuantity())
                .sum();

        // Calcular cantidad total de items
        int quantity = purchaseDTO.getItems().stream().mapToInt(PurchaseItemDTO::getQuantity).sum();

        //Mappear itemsDTo a itemsEntity
        List<PurchaseItem> items = purchaseDTO.getItems().stream()
                .map(itemDTO -> {
                    return mapper.toEntity(itemDTO);
                })
                .toList();

        //Crear purchaseEntity
        Purchase new_purchase = new Purchase(userId, actualDate, quantity, items, totalPrice);

        purchaseRepository.save(new_purchase);
        return mapper.toDTO(new_purchase);
    }

    public List<PurchaseDTO> getAllPurchases() {
        return null;
    }

    public PurchaseDTO getPurchaseById(Long purchaseId) {
        return null;
    }
}
