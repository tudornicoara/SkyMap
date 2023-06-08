<script>
  import {onMount, onDestroy} from "svelte";
  import DiscoverySourceTypeStore from "./stores/discoverySourceTypeStore.ts";
  import DiscoverySourceStore from "./stores/discoverySourceStore.ts";
  import CelestialObjectTypeStore from "./stores/celestialObjectTypeStore.ts";
  import CelestialObjectStore from "./stores/celestialObjectStore.ts";

  let discoverySourceTypeList = [];
  let discoverySourceList = [];
  let celestialObjectTypeList = [];
  let celestialObjectList = [];
  
  onMount(async () => {
    await DiscoverySourceTypeStore.loadDiscoverySourceTypes();
    await DiscoverySourceStore.loadDiscoverySources();
    await CelestialObjectTypeStore.loadCelestialObjectTypes();
    await CelestialObjectStore.loadCelestialObjects();
  })

  const unsubscribeDiscoverySourceTypes = DiscoverySourceTypeStore.getDiscoverySourceTypes().subscribe(value => {
    discoverySourceTypeList = value;
  })
  const unsubscribeCelestialObjectTypes = CelestialObjectTypeStore.getCelestialObjectTypes().subscribe(value => {
    celestialObjectTypeList = value;
  })
  const unsubscribeDiscoverySources = DiscoverySourceStore.getDiscoverySources().subscribe(value => {
    discoverySourceList = value;
  })
  const unsubscribeCelestialObjects = CelestialObjectStore.getCelestialObjects().subscribe(value => {
    celestialObjectList = value;
  })
  
  onDestroy(() => {
    unsubscribeDiscoverySourceTypes();
    unsubscribeCelestialObjectTypes();
    unsubscribeDiscoverySources();
    unsubscribeCelestialObjects();
  })
</script>

<main>
  <h3>Discovery Source Types</h3>
  
  <ul>
    {#each discoverySourceTypeList as discoverySourceType}
      <li>{discoverySourceType.name}</li>
    {/each}
  </ul>

  <h3>Discovery Sources</h3>

  <ul>
    {#each discoverySourceList as discoverySource}
      <li>{discoverySource.name}</li>
    {/each}
  </ul>

  <h3>Celestial Object Types</h3>

  <ul>
    {#each celestialObjectTypeList as celestialObjectType}
      <li>{celestialObjectType.name}</li>
    {/each}
  </ul>

  <h3>Celestial Objects</h3>

  <ul>
    {#each celestialObjectList as celestialObject}
      <li>{celestialObject.name}</li>
    {/each}
  </ul>
</main>
