using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Notes.Mobile.Services.Bases;

/// <summary>
/// Class BaseService.
/// Implements the <see cref="IBaseService{TEntity}" />
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
/// <seealso cref="IBaseService{TEntity}" />
public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected virtual string BasePath => nameof(TEntity).ToLower();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseService{TEntity}"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    protected BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Get all as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;IEnumerable`1&gt; representing the asynchronous operation.</returns>
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var result = await _httpClient.GetStringAsync($"api/{BasePath}");
        return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(result);
    }

    /// <summary>
    /// Get identifier as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;TEntity&gt; representing the asynchronous operation.</returns>
    public virtual async Task<string> GetIdAsync(int id)
    {
        var result = await _httpClient!.GetStringAsync($"api/{BasePath}/{id}");
        return result;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public virtual async Task<HttpResponseMessage> DeleteAsync(int id)
    {
        var result = await _httpClient?.DeleteAsync($"api/{BasePath}/{id}")!;
        return result;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public virtual async Task<HttpResponseMessage> CreateAsync(TEntity entity)
    {
        HttpResponseMessage result = new HttpResponseMessage();
        var serializeObject = JsonConvert.SerializeObject(entity);
        using (HttpContent httpContent = new StringContent(serializeObject))
        {
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            result = await _httpClient?.PostAsync($"api/{BasePath}/Create", httpContent)!;
        }

        return result;
    }

    /// <summary>
    /// Update as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public virtual async Task<HttpResponseMessage> UpdateAsync(TEntity entity)
    {
        HttpResponseMessage result = new HttpResponseMessage();
        var serializeObject = JsonConvert.SerializeObject(entity);
        using (HttpContent httpContent = new StringContent(serializeObject))
        {
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            result = await _httpClient?.PutAsync($"api/{BasePath}/Update", httpContent)!;
        }

        return result;
    }

    public byte[] ObjectToByteArray(TEntity obj)
    {
        if (obj == null)
            return null;
        var bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}