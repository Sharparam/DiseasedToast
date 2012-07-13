using System;
using System.ComponentModel;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using TiledLib;

using F16Gaming.Game.Content.Pipeline.Tiled;

using TInput = TiledLib.MapContent;
using TOutput = F16Gaming.Game.Content.Pipeline.Tiled.MapContent;

namespace F16Gaming.Game.Content.Pipeline
{
	[ContentProcessor(DisplayName = "TMX Processor - F16Gaming.Game.Content")]
	public class MapProcessor : ContentProcessor<TInput, TOutput>
	{
		[DisplayName("Tileset Directory")]
		[Description("The directory (relative to content root) in which the processor will find the tileset images. If left blank, the tilesets are assumed to be in the \"Tilesets\" folder.")]
		public string TilesetDirectory { get; set; }

		public override TOutput Process(TInput input, ContentProcessorContext context)
		{
			string tilesetPath = string.IsNullOrEmpty(TilesetDirectory) ? "Tilesets" : TilesetDirectory;

			// Build the textures
			TiledHelpers.BuildTileSetTextures(input, context, tilesetPath);

			// Generate source rectangles
			TiledHelpers.GenerateTileSourceRectangles(input, tilesetPath);

			// Build output, copy data
			var output = new TOutput
			{
				Filename = input.Filename,
				Directory = input.Directory,
				Version = input.Version,
				Orientation = (byte) input.Orientation,
				Width = input.Width,
				Height = input.Height,
				TileWidth = input.TileWidth,
				TileHeight = input.TileHeight
			};

			foreach (var property in input.Properties)
				output.Properties.Add(property.Key, property.Value);

			// Iterate all layers of the input
			foreach (var layer in input.Layers)
			{
				Tiled.LayerContent layerContent = null;

				if (layer.Type == "layer")
				{
					// We only care about tile layers at the moment
					var tlc = layer as TiledLib.TileLayerContent;
					if (tlc != null)
					{
						// Create new layer
						layerContent = new Tiled.TileLayerContent
						{
							Tiles = new TileContent[tlc.Data.Length]
						};

						foreach (var property in layer.Properties)
						{
							layerContent.Properties.Add(property.Key, property.Value);
						}

						// Build up tile list
						for (int i = 0; i < tlc.Data.Length; i++)
						{
							bool empty = false;

							// Get ID of tile
							uint tileID = tlc.Data[i];

							// Use ID to get actual index and SpriteEffects
							int tileIndex;
							SpriteEffects spriteEffects;
							TiledHelpers.DecodeTileID(tileID, out tileIndex, out spriteEffects);

							// Find out which tileset has this tile index in it and
							// grab the texture reference and source rectangle.
							ExternalReference<Texture2DContent> textureContent = null;
							var sourceRect = new Rectangle();

							// Iterate all the tilesets
							foreach (var tileSet in input.TileSets)
							{
								// If tile index is in this set
								if (tileIndex - tileSet.FirstId < 0)
								{
									empty = true;
									break;
								}

								if (tileIndex - tileSet.FirstId < tileSet.Tiles.Count)
								{
									// Store texture content and source rectangle
									
									textureContent = tileSet.Texture;
									sourceRect = tileSet.Tiles[tileIndex - tileSet.FirstId].Source;

									// Break out of foreach
									break;
								}
							}

							// Insert tile into output
							if (empty)
								((Tiled.TileLayerContent) layerContent).Tiles[i] = null;
							else
							{
								((Tiled.TileLayerContent)layerContent).Tiles[i] = new TileContent
								{
									Texture = textureContent,
									SourceRectangle = sourceRect,
									SpriteEffects = spriteEffects
								};
							}
						}
					}
				}
				else if (layer.Type == "objectgroup")
				{
					var molc = layer as TiledLib.MapObjectLayerContent;

					if (molc != null)
					{
						layerContent = new Tiled.MapObjectLayerContent
						{
							Color = molc.Color
						};

						foreach (var moc in molc.Objects)
						{
							var mapObject = new Tiled.MapObjectContent
							{
								Name = moc.Name,
								Type = moc.Type,
								GID = moc.GID,
								ObjectType = (byte) moc.ObjectType,
								Bounds = new Rectangle(moc.Bounds.X, moc.Bounds.Y, moc.Bounds.Width, moc.Bounds.Height)
							};

							foreach (var point in moc.Points)
								mapObject.Points.Add(new Vector2(point.X, point.Y));

							foreach (var property in moc.Properties)
								mapObject.Properties.Add(property.Key, property.Value);

							((Tiled.MapObjectLayerContent)layerContent).Objects.Add(mapObject);
						}
					}
				}

				Debug.Assert(layerContent != null, "layerContent != null");

				layerContent.Name = layer.Name;
				layerContent.Type = layer.Type;
				layerContent.Opacity = layer.Opacity;
				layerContent.Visible = layer.Visible;
				layerContent.Width = layer.Width;
				layerContent.Height = layer.Height;

				// Add layer to output
				output.Layers.Add(layerContent);
			}

			// Return output object
			return output;
		}
	}
}