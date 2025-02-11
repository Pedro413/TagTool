﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;
using TagTool.Bitmaps.DDS;
namespace TagTool.Bitmaps
{
    public class BitmapExtractor
    {
        private HaloOnlineCacheContext CacheContext { get; }

        public BitmapExtractor(HaloOnlineCacheContext cacheContext)
        {
            CacheContext = cacheContext;
        }

        public void ExtractBitmap(Bitmap bitmap, int imageIndex, Stream outStream)
        {
            var resource = bitmap.Resources[imageIndex];
            var resourceContext = new ResourceSerializationContext(CacheContext, resource.Resource);
            var definition = ExtractResourceDefinition(resource, resourceContext);

            var header = new DDSHeader(definition.Texture.Definition);

            header.Write(new EndianWriter(outStream));

            ExtractResourceData(definition, resource, outStream);

        }

        private BitmapTextureInteropResource ExtractResourceDefinition(Bitmap.BitmapResource resource, ResourceSerializationContext context)
        {
            var definition = CacheContext.Deserializer.Deserialize<BitmapTextureInteropResource>(context);
            if (definition.Texture == null || definition.Texture.Definition == null)
                throw new ArgumentException("Invalid bitmap definition");
            return definition;
        }

        private void ExtractResourceData(BitmapTextureInteropResource definition, Bitmap.BitmapResource resource, Stream outStream)
        {
            var dataReference = definition.Texture.Definition.Data;
            if (dataReference.Address.Type != CacheResourceAddressType.Resource)
                throw new InvalidOperationException("Invalid resource data address");

            var resourceDataStream = new MemoryStream();
            CacheContext.ExtractResource(resource.Resource, resourceDataStream);
            resourceDataStream.Position = dataReference.Address.Offset;
            StreamUtil.Copy(resourceDataStream, outStream, dataReference.Size);
        }
    }
}
