import net.minecraft.block.Block;
import net.minecraft.block.material.Material;

public class BlockForce extends Block {
    
    public BlockForce() {
        super(Block.Properties.create(Material.ROCK) // Set the material of the block
                .hardnessAndResistance(1.5f, 6.0f) // Set hardness and resistance
                .lightValue(15)); // Set light level
        setRegistryName("force_block"); // Set the registry name
    }
}
