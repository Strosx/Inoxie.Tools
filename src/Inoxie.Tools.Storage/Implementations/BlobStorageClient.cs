﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Inoxie.Tools.Storage.Implementations.Internal;
using Inoxie.Tools.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Inoxie.Tools.Storage.Implementations;

internal class BlobStorageClient : IBlobStorageClient
{
    private readonly InoxieBlobClient inoxieBlobClient;

    /// <summary>
    /// Represents a client for managing interactions with Azure Blob Storage.
    /// This client provides functionalities for uploading, downloading, deleting blobs, and retrieving metadata, specifically tailored for Inoxie's needs.
    /// </summary>
    public BlobStorageClient(InoxieBlobClient inoxieBlobClient)
    {
        this.inoxieBlobClient = inoxieBlobClient;
    }

    public async Task DeleteAsync(string blobUri)
    {
        var uri = new Uri(blobUri);
        if (uri.Host != inoxieBlobClient.Host)
        {
            throw new Exception("Wrong storage Host!");
        }

        var (containerName, blobName) = GetBlobClient(uri);

        var container = await inoxieBlobClient.GetContainer(containerName);
        var blobClient = container.GetBlobClient(blobName);

        await blobClient.DeleteAsync();
    }

    public async Task<Stream> DownloadAsync(string blobUri)
    {
        var uri = new Uri(blobUri);
        if (uri.Host != inoxieBlobClient.Host)
        {
            throw new Exception("Wrong storage Host!");
        }

        var (containerName, blobName) = GetBlobClient(uri);

        var container = await inoxieBlobClient.GetContainer(containerName);
        var blobClient = container.GetBlobClient(blobName);
        var stream = new MemoryStream();
        await blobClient.DownloadToAsync(stream);
        return stream;
    }

    public async Task<IDictionary<string, string>> GetMetadataAsync(string blobUri)
    {
        var uri = new Uri(blobUri);
        if (uri.Host != inoxieBlobClient.Host)
        {
            throw new Exception("Wrong storage Host!");
        }

        var (containerName, blobName) = GetBlobClient(uri);

        var container = await inoxieBlobClient.GetContainer(containerName);
        var blobClient = container.GetBlobClient(blobName);

        var properties = await blobClient.GetPropertiesAsync();
        return properties.Value.Metadata;
    }

    public async Task<string> UploadAsync(Stream stream, string containerName, string blobName = null, string contentType = null, IDictionary<string, string> metadata = null)
    {
        var container = await inoxieBlobClient.GetContainer(containerName);

        blobName ??= Guid.NewGuid().ToString();

        var blobClient = container.GetBlobClient(blobName);

        if (metadata != null) await blobClient.SetMetadataAsync(metadata);

        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType ?? "application/octet-stream" });

        return blobClient.Uri.AbsoluteUri;
    }

    private static (string containerName, string blobName) GetBlobClient(Uri uri)
    {
        var uriClient = new BlobClient(uri);
        var containerName = uriClient.BlobContainerName;
        var blobName = uriClient.Name;

        return (containerName, blobName);
    }
}