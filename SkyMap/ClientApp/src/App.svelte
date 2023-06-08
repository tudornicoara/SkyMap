<script>
  import {onMount, onDestroy} from "svelte";
  import DiscoverySourceTypeStore from "./stores/discoverySourceTypeStore.ts";

  let discoverySourceTypeList = [];
  
  onMount(async () => {
    await DiscoverySourceTypeStore.loadDiscoverySourceTypes();
  })

  const unsubscribe = DiscoverySourceTypeStore.getDiscoverySourceTypes().subscribe(value => {
    discoverySourceTypeList = value;
  })
  
  onDestroy(() => {
    unsubscribe();
  });
</script>

<main>
  <h3>Discovery Source Types</h3>
  
  <ul>
    {#each discoverySourceTypeList as discoverySourceType}
      <li>{discoverySourceType.name}</li>
    {/each}
  </ul>
  
</main>
